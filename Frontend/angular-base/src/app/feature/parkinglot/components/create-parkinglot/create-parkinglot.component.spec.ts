import { ComponentFixture, TestBed } from "@angular/core/testing";
import { AppModule } from "src/app/app.module";

import { CreateParkinglotComponent } from "./create-parkinglot.component";

describe("CreateParkinglotComponent", () => {
  let component: CreateParkinglotComponent;
  let fixture: ComponentFixture<CreateParkinglotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateParkinglotComponent],
      imports: [AppModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateParkinglotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
