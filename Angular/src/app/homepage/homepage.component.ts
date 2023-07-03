import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ScrollService } from '../service/scroll.service';


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent 
{
  
  constructor(private router:Router, private scrollService: ScrollService)
  {
   
  }

  scrollToId(id: string) {
    console.log("element id : ", id);
    this.scrollService.scrollToElementById(id);
  }

  scrollToElement(element: HTMLElement) {
    this.scrollService.scrollToElement(element);
  }
  
  logout()
  {
    this.router.navigateByUrl('login');
  }

  loginPage()
  {
    this.router.navigateByUrl('login');
  }
  

}
