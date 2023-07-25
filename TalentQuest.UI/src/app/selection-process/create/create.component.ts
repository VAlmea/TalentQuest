import { Component, OnInit } from '@angular/core';
import { RecruiterService } from 'src/app/services/recruiter.service';
import { Recruiter } from 'src/app/Interfaces/Recruiter';
import { SelectionProcessService } from 'src/app/services/selection-process.service';
import { map } from 'rxjs';
import { FormControl } from '@angular/forms';
import { SelectionProcessRequest } from 'src/app/Interfaces/SelectionProcessRequest';
@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  constructor(private selectionProcessService: SelectionProcessService, private recruiterService: RecruiterService) { }
  recruiters: Recruiter[] = [];
  recruitersControl = new FormControl('');
  selectionProcess: SelectionProcessRequest = {} as SelectionProcessRequest;

  ngOnInit(){
    this.recruiterService.getRecruiters().pipe(
      map(response => response.data)
    ).subscribe(data=>{
      this.recruiters = data;
    })   
  }
  
  save(){
    this.selectionProcessService.createProcess(this.selectionProcess).subscribe(data=>{
      console.log("success");
    })
  }
}
