import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';

// TODO: Replace this with your own data model type
export interface SubmissionsItem {
    rep: string;
    vendor: string;
    primeVendor: string;
    client: string;
    implementationPartnerVendor: string;
    vendorPerson: string;
    vendorContact: number;
    primeVendorPerson: string;
    primeVendorContact: number;
    firstCommunication: string;
    role: string;
    domain: string;
    toolStack: string;
    submissionAndProcess: string;
    status: string;
    reasonOnDecision: string;
    updates: string;
    id: number;
}

// TODO: replace this with real data from your application
export const EXAMPLE_DATA: SubmissionsItem[] = [
  {id: 1, rep: 'Darab', vendor: 'Kiyani', primeVendor: 'sda', client: 'dadf',
  implementationPartnerVendor: 'daredu', vendorPerson: 'dfa', vendorContact: 12341,
   primeVendorPerson: 'dasf', primeVendorContact: 1341, firstCommunication: '141',
  role: 'adf', domain: 'aafa', toolStack: 'afafa', submissionAndProcess: 'af',
status: 'Ongoing', reasonOnDecision: 'adf', updates: 'ad' },
];

/**
 * Data source for the Submissions view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export default class SubmissionsDataSource extends DataSource<SubmissionsItem> {
  data: SubmissionsItem[] = EXAMPLE_DATA;
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
  connect(): Observable<SubmissionsItem[]> {
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
  private getPagedData(data: SubmissionsItem[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: SubmissionsItem[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort.direction === 'asc';
      switch (this.sort.active) {
        case 'rep': return compare(a.rep, b.rep, isAsc);
        case 'vendor': return compare(a.vendor, b.vendor, isAsc);
        case 'id': return compare(+a.id, +b.id, isAsc);
        case 'primeVendor': return compare(a.primeVendor, b.primeVendor, isAsc);
        case 'client': return compare(a.client, b.client, isAsc);
        case 'implementationPartnerVendor': return compare(a.implementationPartnerVendor, b.implementationPartnerVendor, isAsc);
        case 'vendorPerson': return compare(a.vendorPerson, b.vendorPerson, isAsc);
        case 'vendorContact': return compare(+a.id, +b.id, isAsc);
        case 'primeVendorPerson': return compare(a.primeVendorPerson, b.primeVendorPerson, isAsc);
        case 'primeVendorContact': return compare(+a.id, +b.id, isAsc);
        case 'role': return compare(a.role, b.role, isAsc);
        case 'domain': return compare(a.domain, b.domain, isAsc);
        case 'toolStack': return compare(a.toolStack, b.toolStack, isAsc);
        case 'submissionAndProcess': return compare(a.submissionAndProcess, b.submissionAndProcess, isAsc);
        case 'reasonOnDecision': return compare(a.reasonOnDecision, b.reasonOnDecision, isAsc);
        case 'updates': return compare(a.updates, b.updates, isAsc);
        default: return 0;
      }
    });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
