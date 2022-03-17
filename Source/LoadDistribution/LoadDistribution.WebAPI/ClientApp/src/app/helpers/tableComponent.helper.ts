import { AfterViewInit, Component, Inject, OnInit, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import Client from "../clients/client.client";
import BaseDTO from "../models/dto/baseDTO.model";
import { ProjectHandler } from "./projectHandler.helper";
import TableDataSource from "./tableDataSource.helper";

@Component({ template: '' })
export default abstract class TableComponent<TDTO extends BaseDTO> implements OnInit, AfterViewInit {
    // table
  dataSource: TableDataSource<TDTO> = new TableDataSource<TDTO>(this._client);
  displayedColumns: string[] = ['id', 'created', 'updated', ...this._columns, 'actions'];

  // paginator
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private readonly _client: Client<TDTO>,
    @Inject(String) private readonly _columns: string[],
    private readonly _projectHandler: ProjectHandler | null = null
  ) { }

  ngOnInit(): void {
    this.dataSource.loadPage();
    this._projectHandler && this.dataSource.addProjectHandler(this._projectHandler);
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