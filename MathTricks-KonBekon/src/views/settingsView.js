import { html } from '../library.js';

let settingsView = () => html`
<div class="container">
    <h3 class="title">Settings</h3>
    <br>
    <br>

    <h2 class="secondaryText">Background Music</h2>
    

       <img id="muteMusicImg" class="settingsSoundOnImg" src="../../resources/soundOff.png">

    <h2 class="secondaryText">Volume</h2>
    <input type="range" id="volumeSlider" min="0" max="100" step="1" value="50">
</div>
`;

export async function showSettings(ctx) {
    ctx.render(settingsView(muteMusic));

    let muteImgElement = document.getElementById("muteMusicImg");
    muteImgElement.addEventListener('click', muteMusic);

    let volumeSlider = document.getElementById("volumeSlider");
    volumeSlider.addEventListener("input", volumeChange);

    function muteMusic(e) {
        e.preventDefault();
        if (ctx.audio.paused == true) {
            ctx.audio.play();
            e.target.src="../../resources/soundOn.png";
        }
        else {
            ctx.audio.pause();
            e.target.src="../../resources/soundOff.png";
        }
    }

    function volumeChange() {
        let sliderValue = volumeSlider.value;
        ctx.audio.volume = sliderValue / 100;
    }

}



