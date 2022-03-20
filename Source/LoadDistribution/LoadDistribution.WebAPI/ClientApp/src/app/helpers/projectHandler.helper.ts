import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import ProjectDTO from "../models/dto/models/projectDTO.model";

@Injectable({
    providedIn: 'root'
})
export class ProjectHandler {
    private readonly _storageKey: string = 'ProjectSubject.SelectedProject';

    private readonly _selected$: BehaviorSubject<ProjectDTO | null> = new BehaviorSubject<ProjectDTO | null>(this._getSelected());
    private readonly _inserted$: BehaviorSubject<ProjectDTO | null> = new BehaviorSubject<ProjectDTO | null>(null);
    private readonly _updated$: BehaviorSubject<ProjectDTO | null> = new BehaviorSubject<ProjectDTO | null>(null);
    private readonly _deleted$: BehaviorSubject<ProjectDTO | null> = new BehaviorSubject<ProjectDTO | null>(null);

    private _getSelected() : ProjectDTO | null {
        const json: string | null = localStorage.getItem(this._storageKey);
        return json ? JSON.parse(json) : null;
    }

    get selected$(): Observable<ProjectDTO | null> {
        return this._selected$;
    }

    get selected(): ProjectDTO | null {
        return this._selected$.value;
    }

    set selected(value: ProjectDTO | null) {
        localStorage.setItem(this._storageKey, JSON.stringify(value));
        this._selected$.next(value);
    }

    get inserted$(): Observable<ProjectDTO | null> {
        return this._inserted$;
    }

    get inserted(): ProjectDTO | null {
        return this._inserted$.value;
    }

    set inserted(value: ProjectDTO | null) {
        this._inserted$.next(value);
    }

    get updated$(): Observable<ProjectDTO | null> {
        return this._updated$;
    }

    get updated(): ProjectDTO | null {
        return this._updated$.value;
    }

    set updated(value: ProjectDTO | null) {
        this._updated$.next(value);
        if(value?.id == this.selected?.id) {
            this.selected = value;
        }
    }

    get deleted$(): Observable<ProjectDTO | null> {
        return this._deleted$;
    }

    get deleted(): ProjectDTO | null {
        return this._deleted$.value;
    }

    set deleted(value: ProjectDTO | null) {
        this._deleted$.next(value);
        if(value?.id == this.selected?.id) {
            this.selected = null;
        }
    }
}