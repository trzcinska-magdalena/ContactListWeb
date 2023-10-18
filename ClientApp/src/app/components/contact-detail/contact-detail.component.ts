import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../../models/category';
import { Contact } from '../../models/contact';
import { Subcategory } from '../../models/subcategory';
import { ContactListService } from '../../service/contact-list.service';

@Component({
  selector: 'app-contact-detail',
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.css']
})
export class ContactDetailComponent implements OnInit {
  contact: Contact = {
      id: 0,
      name: '',
      surname: '',
      email: '',
      password: '',
      phone: '',
      birthDate: undefined,
      categoryID: 0,
      subcategoryID: 0,
      subcategoryOther: null
  }
  categories: Category[] = [];
  subcategories: Subcategory[] = [];
  errors: string[] = [];

  constructor(private contactListService: ContactListService, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id');

    this.contactListService.getCategories().subscribe((result: Category[]) => this.categories = result, error => console.error(error));
    this.contactListService.getContact(id).subscribe((result: Contact) => this.contact = result, error => console.error(error));
  }

  onChangeCategory(value: any) {
    const idCategory = value.target.value;
    this.contactListService.getSubategories(idCategory).subscribe((result: Subcategory[]) => this.subcategories = result, error => console.error(error));
  }

  onSaveContact() {
    this.contactListService.updateContact(this.contact)
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
