import { AfterViewInit, Inject, Injectable, OnInit, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import Client from "../clients/client.client";
import BaseDTO from "../models/dto/baseDTO.model";
import CollectionDataSource from "./tableDataSource.helper";

@Injectable()
export default abstract class TableComponent<TDTO extends BaseDTO> implements OnInit, AfterViewInit {
    // table
  dataSource: CollectionDataSource<TDTO> = new CollectionDataSource<TDTO>(this._client);
  displayedColumns: string[] = ['id', 'created', 'updated', ...this._columns, 'actions'];

  // paginator
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private readonly _client: Client<TDTO>,
    @Inject(String) private readonly _columns: string[]
  ) { }

  ngOnInit(): void {
    this.dataSource.loadPage();
  }

  ngAfterViewInit(): void {
    this.dataSource.addPaginator(this.paginator);
  }

  onDeleteBtnClick(id: number): void {
    this._client
      .delete(id)
      .subscribe(() => 
        this.dataSource.loadPage(this.paginator.pageIndex, this.paginator.pageSize)
      );
  }
}