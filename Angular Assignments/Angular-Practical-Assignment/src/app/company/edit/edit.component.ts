import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WebapiService } from 'src/app/webapi.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  companyobj: any;

  constructor(private service:WebapiService,private router:Router,private routers: ActivatedRoute) { }
  

  ngOnInit(): void {
   
  const id=this.routers.snapshot.queryParamMap.get('id');
  this.service.getDetailsById(id).subscribe(data=>{
    
    this.companyobj=data;
  })
  }
  updateCompany()
{
 
  this.service.updateComapny(this.companyobj).subscribe(data=>{
    alert("Data Updated Successfully.")
    setTimeout(() => {
      this.router.navigate(['/index']);
    }, 1000);
  })
}




}
