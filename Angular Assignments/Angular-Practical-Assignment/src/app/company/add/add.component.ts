import { Component, OnInit, AfterViewInit } from '@angular/core';
import { WebapiService } from 'src/app/webapi.service';
import { Router } from '@angular/router';
import{Branch} from '../../branch.model'

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit,AfterViewInit{
 
  ngAfterViewInit(): void {
   
  }

  constructor(private service:WebapiService,private router:Router) { }

  branch=new Branch();
  dataArray=[] as  any;

  isEdit=false;
  companyobj={
    "email":"",
   "name":"", 
  "totalEmployee":"",
  "address":"",
  "isCompanyActive":"",
  "totalBranch":"",
     "companyBranch":[]

  }
  companydata:any;
  ngOnInit(){
    this.branch=new Branch();
    this.dataArray.push(this.branch)
    this.getLatestDetails()
    this.service.currentMsg.subscribe(data=>{
      
      this.companyobj=data;
      this.isEdit=true;
    })

  }
  AddCompany(formobj: any)
  {
    console.log(this.dataArray);
    debugger;
    const data={
                        
                      "email":formobj.email,
                      "name":formobj.name, 
                      "totalEmployee":formobj.totalEmployee,
                      "address":formobj.address,
                      "isCompanyActive":formobj.isCompanyActive,
                      "totalBranch":this.dataArray.length,
                      "companyBranch":this.dataArray
         }
    this.service.createCompany(data).subscribe(res=>{
      alert("Added Successfully.")
      setTimeout(() => {
        this.router.navigate(['/index']);
      }, 1000);
      this.getLatestDetails();
    })
  }

  getLatestDetails(){
    this.service.getAllCompany().subscribe(res=>{
      this.companydata=res;

      console.log(res)
  });
  
}

AddMore()
{
  this.branch=new Branch();
  this.dataArray.push(this.branch);
}

}
