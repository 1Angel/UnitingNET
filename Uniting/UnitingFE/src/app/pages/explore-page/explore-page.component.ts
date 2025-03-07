import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { CommunitiesService } from '../../core/Services/communities.service';
import { Communities } from '../../core/models/Communities-response.interface';
import { Meta, Title } from '@angular/platform-browser';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { CommunitiesListComponent } from "../../components/communities-list/communities-list.component";

@Component({
  selector: 'app-explore-page',
  imports: [CommunitiesListComponent],
  templateUrl: './explore-page.component.html',
  styleUrl: './explore-page.component.css'
})
export class ExplorePageComponent implements OnInit{
  ngOnInit(): void {
    this.GetCommunities();

    this.title.setTitle("Explore Communties - Uniting");
    this.meta.addTag({name: "og:title", content: "Explore Communities - Uniting"});
    this.meta.addTag({name: "description", content: "Communities explore"});
    this.meta.addTag({name: "og:description", content: "Communities explore"});

  }

  private readonly service = inject(CommunitiesService);
  private readonly destroy = inject(DestroyRef);
  private readonly title = inject(Title);
  private readonly meta = inject(Meta);

  public communities = signal<Communities[]>([]);

  GetCommunities(){
    return this.service.GetCommunities()
    .pipe(takeUntilDestroyed(this.destroy))
    .subscribe(response=>{
      this.communities.set(response.data)
    });
  }
}
