import { html } from '../library.js';

let helpView = () => html`
<section>
    <div class="heading">
          <a class= "helpPageReturnButton" href="/">
              <button class="gameButton">Return</button>
          </a>
          <p class="title helpPageTitle"> How to play the game? </p>
    </div>

      <div class="image-container">
          <img src="../../resources/helpPhoto.png">
          <p class="instructions">Hello players! This game is called MathTricks. If you like games with numbers and math 
          operations you will definitely love this one. Let me tell you how to play the game. Player one starts on the 
          first square on our table marked with the color blue and the second starts on the last square marked with 
          the color green. You can move next to the squares that last have been marked. Look at the picture on the left. 
          You start on the left corner and you can move ether on the square with the “3” or the square with the “x2”. 
          The same rules are for both players.
          </p>
      </div>


</section>
`;
export async function showHelp(ctx) {
    ctx.render(helpView());
}
