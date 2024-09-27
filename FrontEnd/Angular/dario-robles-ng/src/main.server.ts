import { bootstrapApplication } from '@angular/platform-browser';
import { config } from './app/core/config/app.config.server';
import { AppComponent } from './app/ui/main/shell/app.component';

const bootstrap = () => bootstrapApplication(AppComponent, config);

export default bootstrap;
