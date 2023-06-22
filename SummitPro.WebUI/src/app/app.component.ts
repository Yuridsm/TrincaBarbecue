import { Component } from '@angular/core';
import { SuperHero } from './models/super-hero';
import { Barbecue } from './models/barbecue';
import { SuperHeroService } from './services/super-hero.service';
import { BarbecueService } from './services/barbecue.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SummitPro.WebUI';
  heroes: SuperHero[] = [];
  barbecue: Barbecue = new Barbecue();

  constructor(
    private superHeroService: SuperHeroService,
    private barbecueService: BarbecueService
    ) {}

  ngOnInit() : void {
    this.heroes = this.superHeroService.getSuperHeros();
    
    this.barbecueService
      .getBarbecueFromAPI()
      .subscribe((result: Barbecue) => (this.barbecue = result));
  }
}
