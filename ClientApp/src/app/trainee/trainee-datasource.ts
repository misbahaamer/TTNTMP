import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';

// TODO: Replace this with your own data model type
export interface TraineeItem {
  firstname: string;
  lastname: string;
  personalPhoneNumber: number;
  marketingPhoneNumber: number;
  personalEmail: string;
  marketingEmail: string;
  status: string;
  dateofBirth: string;
  id: number;
}

// TODO: replace this with real data from your application
export const EXAMPLE_DATA2: TraineeItem[] = [
  {id: 1, firstname: 'Darab', lastname: 'Kiyani', personalPhoneNumber: 8607710436, marketingPhoneNumber: 86014123131, personalEmail:
  'darab.kiyani@uconn.edu', marketingEmail: 'darabkiyani5@gmail.com', status: 'OPT', dateofBirth: '09/03/1990'},
  {id: 2, firstname: 'Misbah', lastname: 'Aamer', personalPhoneNumber: 12311123232, marketingPhoneNumber: 12123121231,
  personalEmail: 'maad@yahoo.com', marketingEmail: 'misbah@gmail.com', status: 'OPT', dateofBirth: '09/07/1989'},
  {id: 3, firstname: 'Harris', lastname: 'Masood', personalPhoneNumber: 1231232112, marketingPhoneNumber: 12312312313,
  personalEmail: 'harad@yahoo.com', marketingEmail: 'harris@gmail.com', status: 'Citizen', dateofBirth: '09/09/1970'},
];

/**
 * Data source for the Trainee view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export default class TraineeDataSource extends DataSource<TraineeItem> {
  data: TraineeItem[] = EXAMPLE_DATA2;
  paginator: MatPaginator;
  sort: MatSort;

  constructor() {
    super();
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<TraineeItem[]> {
    // Combine everything that affects the rendered data into one update
    // stream for the data-table to consume.
    const dataMutations = [
      observableOf(this.data),
      this.paginator.page,
      this.sort.sortChange
    ];

    return merge(...dataMutations).pipe(map(() => {
      return this.getPagedData(this.getSortedData([...this.data]));
    }));
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect() {}

  /**
   * Paginate the data (client-side). If you're using server-side pagination,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getPagedData(data: TraineeItem[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: TraineeItem[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort.direction === 'asc';
      switch (this.sort.active) {
        case 'firstname': return compare(a.firstname, b.firstname, isAsc);
        case 'lastname': return compare(a.lastname, b.lastname, isAsc);
        case 'id': return compare(+a.id, +b.id, isAsc);
        case 'personalPhoneNumber': return compare(+a.id, +b.id, isAsc);
        case 'personalEmail': return compare(a.personalEmail, b.personalEmail, isAsc);
        default: return 0;
      }
    });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
