import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebapiService } from 'src/app/webapi.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  constructor(private service:WebapiService,private router: ActivatedRoute) { }
  companyobj:any
  ngOnInit(): void {
    const id=this.router.snapshot.queryParamMap.get('id');
    
    this.service.getDetailsById(id).subscribe(data=>{
      this.companyobj=data;
    })
  } 

}
