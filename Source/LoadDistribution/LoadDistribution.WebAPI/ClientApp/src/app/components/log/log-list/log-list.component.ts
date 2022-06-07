import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import LogClient from 'src/app/clients/logClient.client';
import TableDataSource from 'src/app/helpers/tableDataSource.helper';
import LogDTO from 'src/app/models/dto/models/logDTO.model';
import { LogType } from 'src/app/models/enums/logType.enum';
import DialogData from 'src/app/models/helpers/models/dialogData.model';
import Localizable from 'src/app/models/helpers/models/localizable.model';
import EnumService from 'src/app/services/enum.service';
import { DialogComponent } from '../../common/dialog/dialog.component';

@Component({
  selector: 'app-log-list',
  templateUrl: './log-list.component.html',
  styleUrls: ['./log-list.component.scss']
})
export class LogListComponent implements OnInit, AfterViewInit {
  // spinner
  readonly spinnerDiameter: number = 20;

  // table
  dataSource: TableDataSource<LogDTO> = new TableDataSource<LogDTO>(this._logClient);
  displayedColumns: string[] = ['id', 'created', 'message', 'type', 'exceptionType', 'details'];

  // paginator
  @ViewChild(MatPaginator) paginator: MatPaginator;

  logTypes: Localizable<number>[] = this._enumService.toLocalizables('logType', LogType);
  
  constructor(
    private readonly _enumService: EnumService,
    private readonly _logClient: LogClient,
    private readonly _dialog: MatDialog
  ) { }

  ngOnInit(): void {
      this.dataSource.loadPage();
  }

  ngAfterViewInit(): void {
    this.dataSource.addPaginator(this.paginator);
  }

  onDetailsClick(log: LogDTO): void {
    this._dialog.open(DialogComponent, {
      data: new DialogData('log.details', log.details)
    });
  }
}
