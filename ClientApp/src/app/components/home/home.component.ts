import { Component, OnInit } from '@angular/core';
import { Contact } from '../../models/contact';
import { ContactListService } from '../../service/contact-list.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  list: Contact[] = [];

  constructor(private contactListService: ContactListService) {
  }

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts() {
    this.contactListService.getContacts().subscribe((result: Contact[]) => this.list = result, error => console.error(error));
  }

  onDelete(id: number): void {
    this.contactListService.deleteContact(id).subscribe((result: Contact) => this.getContacts(), error => console.error(error));
  }
}
