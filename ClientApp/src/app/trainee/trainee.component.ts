import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTable, MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { EXAMPLE_DATA2, TraineeItem } from './trainee-datasource';
import { SelectionModel } from '@angular/cdk/collections';
import { AddTraineeComponent } from './addtrainee.component';
import { TraineeService } from './trainee.service';
import { EXAMPLE_DATA, EmployeesItem } from '../employees/employees-datasource';

@Component({
  selector: 'app-trainee',
  templateUrl: './trainee.component.html',
  styleUrls: ['./trainee.component.css']
})

export class TraineeComponent implements AfterViewInit {
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  @ViewChild(MatTable, {static: false}) table: MatTable<TraineeItem>;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['select', 'id', 'firstname', 'lastname', 'personalPhoneNumber',
   'personalEmail', 'status', 'dateofBirth', 'actions'];
  dataSource = new MatTableDataSource<TraineeItem>(EXAMPLE_DATA2);
  selection = new SelectionModel<TraineeItem>(true, []);
  employeedataSource = new MatTableDataSource<EmployeesItem>(EXAMPLE_DATA);

  removeSelectedRows() {
    this.selection.selected.forEach(item => {
       const index: number = this.dataSource.data.findIndex(d => d === item);
       console.log(this.dataSource.data.findIndex(d => d === item));
       this.dataSource.data.splice(index, 1);
       this.dataSource = new MatTableDataSource<TraineeItem>(this.dataSource.data);
      setTimeout(() => {
        this.ngAfterViewInit();
      });
     });
     this.selection = new SelectionModel<TraineeItem>(true, []);
  }

  transferSelectedRowstoEmployees() {
    this.selection.selected.forEach(item => {
       const index: number = this.dataSource.data.findIndex(d => d === item);
       console.log(this.dataSource.data.findIndex(d => d === item));
       const array: any = this.dataSource.data.splice(index, 1);
       EXAMPLE_DATA.push(array[0]);
       console.log(this.employeedataSource.data);
       this.dataSource = new MatTableDataSource<TraineeItem>(this.dataSource.data);
      setTimeout(() => {
        this.ngAfterViewInit();
      });
     });
     this.selection = new SelectionModel<TraineeItem>(true, []);
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
  checkboxLabel(row?: TraineeItem): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

  constructor(private service: TraineeService,
              public dialog: MatDialog) {}

  openDialog(): void {
    const dialogconfig = new MatDialogConfig();
    dialogconfig.width = '60%';
    dialogconfig.height = '52%';
    dialogconfig.disableClose = true;
    const dialogRef = this.dialog.open(AddTraineeComponent, dialogconfig);
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
    this.selection = new SelectionModel<TraineeItem>(true, []);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    dialogConfig.height = '52%';
    const dialogRef = this.dialog.open(AddTraineeComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(this.service.form.value);
      if (this.service.form.valid) {
        this.selection.selected.forEach(item => {
          const index: number = this.dataSource.data.findIndex(d => d === item);
          console.log(this.dataSource.data.findIndex(d => d === item));
          this.dataSource.data.splice(index, 1, this.service.form.value);
          this.dataSource = new MatTableDataSource<TraineeItem>(this.dataSource.data);
        });
      this.service.form.reset();
      setTimeout(() => {
        this.ngAfterViewInit();
      });
      this.selection = new SelectionModel<TraineeItem>(true, []);
    }
    this.selection = new SelectionModel<TraineeItem>(true, []);
    });
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
