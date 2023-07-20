import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SelectionProcessComponent } from './selection-process/selection-process.component';
import { SelectionProcess } from './Interfaces/SelectionProcess';
import { SelectionProcessService } from './selection-process.service';
import { map } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'TalentQuest';
  SelectionProcesses: SelectionProcess[] = [];
  constructor(private _dialog: MatDialog, private selectionProcessService: SelectionProcessService) { 
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
    this._dialog.open(SelectionProcessComponent);
  }
}
