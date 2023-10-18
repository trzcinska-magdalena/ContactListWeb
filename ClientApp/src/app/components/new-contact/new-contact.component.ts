import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Category } from '../../models/category';
import { Contact } from '../../models/contact';
import { Subcategory } from '../../models/subcategory';
import { ContactListService } from '../../service/contact-list.service';

@Component({
  selector: 'app-new-contact',
  templateUrl: './new-contact.component.html',
  styleUrls: ['./new-contact.component.css']
})
export class NewContactComponent implements OnInit {
  categories: Category[] = [];
  subcategories: Subcategory[] = [];
  categorySelected: string = "";
  contact: Contact = {
    id: 0,
    name: '',
    surname: '',
    email: '',
    password: '',
    phone: '',
    birthDate: undefined,
    categoryID: 0,
    subcategoryID: null,
    subcategoryOther: null
  };
  errors: string[] = [];


  constructor(private contactListService: ContactListService, private router: Router) {
  }

  ngOnInit(): void {
    this.contactListService.getCategories().subscribe((result: Category[]) => this.categories = result, error => console.error(error));
  }

  onChangeCategory(value: any) {
    const idCategory = value.target.value;
    this.contactListService.getSubategories(idCategory).subscribe((result: Subcategory[]) => this.subcategories = result, error => console.error(error));
  }

  onCreateContact(): void {
    this.contactListService.createContact(this.contact)
      .subscribe((
        result: Contact[]) => this.router.navigate(['/']),
        error => {
          console.error(error);

          console.log(error.error.errors);

          for (const key of Object.keys(error.error.errors)) {
            for (const errorMessage of error.error.errors[key]) {
              this.errors.push(`${key}: ${errorMessage}`);
            }
          }

          console.log(this.errors);
        }
      );
  }
}
