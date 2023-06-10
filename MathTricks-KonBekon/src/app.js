import { page, render } from './library.js';
import { showHelp } from './views/helpView.js';
import { showSettingMultiplayer } from './views/settingMultiPlayerView.js';
import { showSettingSinglePlayer} from './views/settingSinglePlayerView.js';
import { showChooseMode } from './views/chooseModeView.js';
import { showHome } from './views/homeView.js';
import { showSettings } from './views/settingsView.js';
import { showMultiPlayerGame } from './views/multiplayer.js'
import { showSinglePlayerGame } from './views/singlePlayer.js'
import { showWinner } from './views/winnerView.js';
import { showStatsView } from './views/statsView.js';


page(contextDecorator)
page('/', showHome);
page('/help', showHelp);
page('/chooseMode', showChooseMode)
page('/settingMultiplayer', showSettingMultiplayer);
page('/settingSinglePlayer', showSettingSinglePlayer);
page('/settings', showSettings);
page('/singlePlayer', showSinglePlayerGame);
page('/multiPlayer', showMultiPlayerGame);
page('/stats', showStatsView);
page('/winner', showWinner);
let mainElement = document.getElementById("mainPage");
let audioElement = document.getElementById("myAudio");


page.start();
page.redirect('/');

async function contextDecorator(ctx, next) {
    ctx.render = (content) => render(content, mainElement);
    ctx.audio = audioElement;
    next();
}
