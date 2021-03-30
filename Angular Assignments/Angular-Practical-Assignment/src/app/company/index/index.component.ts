import { Component, OnInit } from '@angular/core';
import { WebapiService } from 'src/app/webapi.service';
import { Router} from '@angular/router';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
 
  
  constructor(private service:WebapiService,private router:Router) { }

  
  isEdit=false;
  companyobj={
    "email":"",
   "name":"", 
 "totalEmployee":"",
 "address":"",
 "isCompanyActive":"",
"totalBranch":"",
     "companyBranch":[{
     "branchId":"",
     "branchName":"",
     "address":""
     }]

  }
  companydata:any;

  ngOnInit(): void {
  
    this.getLatestDetails()
   
    
  }

  getLatestDetails(){
    this.service.getAllCompany().subscribe(res=>{
      this.companydata=res;

      console.log(res)
  });
  

}

deleteCompany(d: any)
{
  const isdelete=confirm("Are you sure you want to delete?")
 
  if(isdelete)
  {
   
    this.service.deleteCompany(d).subscribe(data=>{
      window.location.reload();
    })
  }
 
}

editCompany(d:any){
  setTimeout(() => {
    
      this.router.navigateByUrl('/edit?id='+d.id).then(() => {
        window.location.reload();
      });
      
    }, 1000);

}

updateCompany()
{
  this.isEdit=!this.isEdit;
  this.service.updateComapny(this.companyobj).subscribe(data=>{
    this.isEdit=false;
  })

  setTimeout(() => {
    this.router.navigate(['/index']).then(() => {
      window.location.reload();
    });
   
  }, 1000);
  
}

showDetails(d:any)
{
  setTimeout(() => {
    this.router.navigateByUrl('/details?id='+d.id).then(() => {
      window.location.reload();
    });
    
  }, 1000);
}
}
