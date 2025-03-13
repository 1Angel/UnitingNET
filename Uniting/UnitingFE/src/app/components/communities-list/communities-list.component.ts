import { Component, input } from '@angular/core';
import { Communities } from '../../core/models/Communities-response.interface';

@Component({
  selector: 'app-communities-list',
  imports: [],
  templateUrl: './communities-list.component.html',
  styleUrl: './communities-list.component.css'
})
export class CommunitiesListComponent {

  communities = input<Communities>();
}
