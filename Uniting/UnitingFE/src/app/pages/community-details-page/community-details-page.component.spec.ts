import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunityDetailsPageComponent } from './community-details-page.component';

describe('CommunityDetailsPageComponent', () => {
  let component: CommunityDetailsPageComponent;
  let fixture: ComponentFixture<CommunityDetailsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommunityDetailsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommunityDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
