import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { ProjectHandler } from '../helpers/projectHandler.helper';

@Injectable({
  providedIn: 'root'
})
export class ProjectRelatedGuard implements CanActivate {
  constructor (
    private readonly _projectHandler: ProjectHandler,
    private readonly _translateService: TranslateService,
    private readonly _snackBar: MatSnackBar
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const isSelected: boolean = !!this._projectHandler.selected;

    if(!isSelected) {
      this._translateService.get([ 'common.snackBar.projectIsNotSelected', 'common.snackBar.close' ])
            .subscribe(literals => this._snackBar.open(literals['common.snackBar.projectIsNotSelected'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'errorSnack' }));
    }

    return isSelected;
  } 
}
