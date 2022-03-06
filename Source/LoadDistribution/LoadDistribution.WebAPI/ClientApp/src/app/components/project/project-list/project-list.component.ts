import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import ProjectClient from 'src/app/clients/projectClient.client';
import CollectionDataSource from 'src/app/helpers/collectionDataSource.helper';
import ProjectDTO from 'src/app/models/dto/projectDTO';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent implements OnInit, AfterViewInit {
  // table
  dataSource: CollectionDataSource<ProjectDTO> = new CollectionDataSource(this._projectClient);
  displayedColumns: string[] = ['id', 'created', 'updated', 'title', 'description', 'actions'];

  // paginator
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private readonly _projectClient: ProjectClient
  ) { }

  ngOnInit(): void {
    this.dataSource.loadPage();
  }

  ngAfterViewInit(): void {
    this.dataSource.addPaginator(this.paginator);
  }

  onDeleteBtnClick(id: number): void {
    this._projectClient
      .delete(id)
      .subscribe(() => 
        this.dataSource.loadPage(this.paginator.pageIndex, this.paginator.pageSize)
      );
  }
}
