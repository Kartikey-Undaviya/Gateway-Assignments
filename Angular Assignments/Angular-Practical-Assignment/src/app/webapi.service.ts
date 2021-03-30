import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class WebapiService {
 

  

  constructor(private http:HttpClient) { }
  defaultd={
    "id":"",
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
 
  };
  private msgSource=new BehaviorSubject<any>(this.defaultd);
  currentMsg=this.msgSource.asObservable();


// npx json-server --watch \\company.json
  changeMsg(msg:any)
  {
 
    this.msgSource.next(msg);
  
  }

  weburl="http://localhost:3000/";
  
  
  createCompany(company: any)
  {

    return this.http.post(this.weburl+"Company",company)
  }

  updateComapny(d:any){
    return this.http.put(this.weburl+"Company/"+d.id,d)
  }

  getAllCompany()
  {
    return this.http.get(this.weburl+"Company")
  }
  deleteCompany(d:any){
    return this.http.delete(this.weburl+"Company/"+d.id)
  }
   getDetailsById(id:any)
  {
    return this.http.get(this.weburl+"Company/"+id)
  }
}
