import { FlatTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import Navigation from 'src/app/models/helpers/navigation.model';
import NavigationFlatNode from 'src/app/models/helpers/navigationFlatNode.model';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {
  treeControl = new FlatTreeControl<NavigationFlatNode>(
    node => node.level,
    node => node.expandable
  );

  treeFlattener = new MatTreeFlattener(
    NavigationFlatNode.toNavigationFlatNode,
    node => node.level,
    node => node.expandable,
    node => node.children
  );

  dataSource = new MatTreeFlatDataSource(
    this.treeControl,
    this.treeFlattener
  );

  constructor() {
    this.dataSource.data = [
      new Navigation("project.projects", "/projects"),
      new Navigation("university.universities", "/universities"),
      new Navigation("activity.activities", "/activities"),
      new Navigation("lecturer.lecturers", "/lecturers"),
      new Navigation("discipline.disciplines", "/disciplines"),
      new Navigation("log.logs", "/logs"),
      new Navigation("common.obsolete", null, [
        new Navigation("lecturerDisciplineActivityMap.lecturerDisciplineActivityMaps", "/lecturerDisciplineActivityMaps"),
        new Navigation("universityLecturerMap.universityLecturerMaps", "/universityLecturerMaps")
      ])
    ];
  }

  hasChild(_: number, node: NavigationFlatNode): boolean {
    return node.expandable;
  }
}
