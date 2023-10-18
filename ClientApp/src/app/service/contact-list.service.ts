import { HttpClient } from '@angular/common/http';
import { Component, Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { Contact } from '../models/contact';
import { Subcategory } from '../models/subcategory';

@Injectable({
  providedIn: 'root',
})
export class ContactListService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  public getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.baseUrl + 'contact');
  }

  public getContact(id: string | null): Observable<Contact> {
    return this.http.get<Contact>(this.baseUrl + 'contact/' + id);
  }

  public getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'contact/category');
  }

  public getSubategories(categoryId: number): Observable<Subcategory[]> {
    return this.http.get<Subcategory[]>(this.baseUrl + '/contact/subcategory/' + categoryId);
  }

  public deleteContact(id: number): Observable<Contact> {
    return this.http.delete<Contact>(this.baseUrl + 'contact/' + id);
  }

  public createContact(contact: Contact): Observable<Contact[]> {
    return this.http.post<Contact[]>(this.baseUrl + 'contact', contact);
  }

  public updateContact(contact: Contact): Observable<Contact[]> {
    return this.http.put<Contact[]>(this.baseUrl + 'contact', contact);
  }
}
