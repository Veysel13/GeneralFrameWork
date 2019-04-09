import { async, TestBed } from '@angular/core/testing';
import { DashboardComponent } from './dashboard.component';
import { HeroSearchComponent } from '../hero-search/hero-search.component';
import { RouterTestingModule } from '@angular/router/testing';
import { of } from 'rxjs';
import { HEROES } from '../mock-heroes';
import { HeroService } from '../hero.service';
describe('DashboardComponent', function () {
    var component;
    var fixture;
    var heroService;
    var getHeroesSpy;
    beforeEach(async(function () {
        heroService = jasmine.createSpyObj('HeroService', ['getHeroes']);
        getHeroesSpy = heroService.getHeroes.and.returnValue(of(HEROES));
        TestBed.configureTestingModule({
            declarations: [
                DashboardComponent,
                HeroSearchComponent
            ],
            imports: [
                RouterTestingModule.withRoutes([])
            ],
            providers: [
                { provide: HeroService, useValue: heroService }
            ]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(DashboardComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should be created', function () {
        expect(component).toBeTruthy();
    });
    it('should display "Top Heroes" as headline', function () {
        expect(fixture.nativeElement.querySelector('h3').textContent).toEqual('Top Heroes');
    });
    it('should call heroService', async(function () {
        expect(getHeroesSpy.calls.any()).toBe(true);
    }));
    it('should display 4 links', async(function () {
        expect(fixture.nativeElement.querySelectorAll('a').length).toEqual(4);
    }));
});
//# sourceMappingURL=dashboard.component.spec.js.map