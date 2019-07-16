import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTable, MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { EXAMPLE_DATA, EmployeesItem } from './employees-datasource';
import { SelectionModel } from '@angular/cdk/collections';
import { AddEmployeesComponent } from './addemployees.component';
import { EmployeeService } from './employees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})

export class EmployeesComponent implements AfterViewInit {
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  @ViewChild(MatTable, {static: false}) table: MatTable<EmployeesItem>;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['select', 'id', 'name', 'actions'];
  dataSource = new MatTableDataSource<EmployeesItem>(EXAMPLE_DATA);
  selection = new SelectionModel<EmployeesItem>(true, []);

  removeSelectedRows() {
    this.selection.selected.forEach(item => {
       const index: number = this.dataSource.data.findIndex(d => d === item);
       console.log(this.dataSource.data.findIndex(d => d === item));
       this.dataSource.data.splice(index, 1);
       this.dataSource = new MatTableDataSource<EmployeesItem>(this.dataSource.data);
      setTimeout(() => {
        this.ngAfterViewInit();
      });
     });
     this.selection = new SelectionModel<EmployeesItem>(true, []);
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.dataSource.data.forEach(row => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: EmployeesItem): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

  constructor(private service: EmployeeService,
              public dialog: MatDialog) {}

  openDialog(): void {
    const dialogconfig = new MatDialogConfig();
    dialogconfig.width = '750px';
    dialogconfig.height = '400px';
    dialogconfig.disableClose = true;
    const dialogRef = this.dialog.open(AddEmployeesComponent, dialogconfig);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(this.service.form.value);
      if (this.service.form.valid) {
      this.dataSource.data.push(this.service.form.value);
      this.service.form.reset();
      setTimeout(() => {
        this.ngAfterViewInit();
      });
    }
    });
  }

  onEdit(row) {
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    const dialogRef = this.dialog.open(AddEmployeesComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(this.service.form.value);
      if (this.service.form.valid) {
        this.selection.selected.forEach(item => {
          const index: number = this.dataSource.data.findIndex(d => d === item);
          console.log(this.dataSource.data.findIndex(d => d === item));
          this.dataSource.data.splice(index, 1, this.service.form.value);
          this.dataSource = new MatTableDataSource<EmployeesItem>(this.dataSource.data);
        });
      this.service.form.reset();
      setTimeout(() => {
        this.ngAfterViewInit();
      });
      this.selection = new SelectionModel<EmployeesItem>(true, []);
    }
    });
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
