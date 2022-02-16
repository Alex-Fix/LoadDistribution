import ActivityDTO from "../models/dto/activityDTO.model";
import BaseClient from "./baseClient.client";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export default class ActivityClient extends BaseClient<ActivityDTO> {
    constructor(
        client: HttpClient 
    ) {
        super('activity', client);
    }
}