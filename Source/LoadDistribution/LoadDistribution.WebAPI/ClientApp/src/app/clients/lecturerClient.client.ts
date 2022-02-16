import LecturerDTO from "../models/dto/lecturerDTO.model";
import BaseClient from "./baseClient.client";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export default class LecturerClient extends BaseClient<LecturerDTO> {
    constructor(
        client: HttpClient
    ) {
        super('lecturer', client);
    }
}