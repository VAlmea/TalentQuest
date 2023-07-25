import { Component } from '@angular/core';
import {FormControl} from '@angular/forms';
import { SelectionProcessService } from '../services/selection-process.service';
import { RecruiterService } from '../services/recruiter.service';
import { SelectionProcessRequest } from '../Interfaces/SelectionProcessRequest';
import { OnInit } from '@angular/core';
import { Recruiter } from '../Interfaces/Recruiter';
import { MatDialog } from '@angular/material/dialog';
import { SelectionProcess } from '../Interfaces/SelectionProcess';
import { map } from 'rxjs';
import { CreateComponent } from './create/create.component';

@Component({
  selector: 'app-selection-process',
  templateUrl: './selection-process.component.html',
  styleUrls: ['./selection-process.component.scss'],
})
export class SelectionProcessComponent implements OnInit {
  SelectionProcesses: SelectionProcess[] = [];

  constructor(private _dialog: MatDialog, private selectionProcessService: SelectionProcessService, private recruiterService: RecruiterService ) { }
    
  ngOnInit(){ 
    this.getProcesses();
  }

  getProcesses(){
    this.selectionProcessService.getProcess().pipe(
      map(response => response.data)
    ).subscribe(data=>{
      this.SelectionProcesses = data;
    })
  }
  deleteProcess(id: string){
    console.log("deleteProcess");
    this.selectionProcessService.removeProcess(id).subscribe(data=>{
      console.log("success");
      this.getProcesses();
    })  
  }
  openAddEditProcessForm(){
    this._dialog.open(CreateComponent).afterClosed().subscribe(result => {
      this.getProcesses();
    })
  }
}
