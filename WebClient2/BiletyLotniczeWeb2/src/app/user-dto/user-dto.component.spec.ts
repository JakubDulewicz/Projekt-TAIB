import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDtoComponent } from './user-dto.component';

describe('UserDtoComponent', () => {
  let component: UserDtoComponent;
  let fixture: ComponentFixture<UserDtoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserDtoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserDtoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
