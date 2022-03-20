import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import ProjectDTO from "../models/dto/models/projectDTO.model";

@Injectable({
    providedIn: 'root'
})
export class ProjectHandler {
    private readonly _storageKey: string = 'ProjectSubject.SelectedProject';

    private readonly _selected$: BehaviorSubject<ProjectDTO | null> = new BehaviorSubject<ProjectDTO | null>(this._getSelected());
    private readonly _insertedId$: BehaviorSubject<number | null> = new BehaviorSubject<number | null>(null);
    private readonly _updatedId$: BehaviorSubject<number | null> = new BehaviorSubject<number | null>(null);
    private readonly _deletedId$: BehaviorSubject<number | null> = new BehaviorSubject<number | null>(null);

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

    get insertedId$(): Observable<number | null> {
        return this._insertedId$;
    }

    get insertedId(): number | null {
        return this._insertedId$.value;
    }

    set insertedId(value: number | null) {
        this._insertedId$.next(value);
    }

    get updatedId$(): Observable<number | null> {
        return this._updatedId$;
    }

    get updatedId(): number | null {
        return this._updatedId$.value;
    }

    set updatedId(value: number | null) {
        this._updatedId$.next(value);
    }

    get deletedId$(): Observable<number | null> {
        return this._deletedId$;
    }

    get deletedId(): number | null {
        return this._deletedId$.value;
    }

    set deletedId(value: number | null) {
        this._deletedId$.next(value);
        if(value == this.selected?.id) {
            this.selected = null;
        }
    }
}