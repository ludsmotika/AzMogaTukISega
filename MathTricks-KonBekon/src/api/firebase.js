
const firebaseConfig = {
    apiKey: "AIzaSyC8ihU8oXvFx85Yt8eoM9ZYEiWlXoa2juQ",
    authDomain: "az-moga-tuk-i-sega-e929e.firebaseapp.com",
    databaseURL: "https://az-moga-tuk-i-sega-e929e-default-rtdb.europe-west1.firebasedatabase.app",
    projectId: "az-moga-tuk-i-sega-e929e",
    storageBucket: "az-moga-tuk-i-sega-e929e.appspot.com",
    messagingSenderId: "480810352077",
    appId: "1:480810352077:web:82dea1f8e47a1691f11884"
};


// Initialize Firebase

firebase.initializeApp(firebaseConfig);
var database = firebase.database();
const dataRefMultiplayer = database.ref("/Scores/Multiplayer");


//functions to read and write data into the real-time database

//multiplayer

export async function addLastGame(playerOneName, playerTwoName, playerOneScore, playerTwoScore) {

    //remove the oldest game

    await dataRefMultiplayer.once("value", async (snapshot) => {
        // The data snapshot contains the retrieved data
        const data = snapshot.val();
        const scoresArray = [...Object.entries(data)];

        await dataRefMultiplayer.child(scoresArray[0][0]).remove();
    });

    //add the last one
    var gameData = {
        playerOneName,
        playerTwoName,
        playerOneScore,
        playerTwoScore
    }

    const newDataRef = dataRefMultiplayer.push();
    newDataRef.set(gameData);
}

export async function getLastMultiplayerGamesData() {

    let lastGames=new Object();

    await dataRefMultiplayer.once("value", async (snapshot) => {
        // The data snapshot contains the retrieved data
        const data = await snapshot.val();
        const scoresArray = [...Object.entries(data)];

        lastGames = scoresArray;
    });

    return lastGames;

}


//singlePlayer


export async function getTopScores() {
    let data;
    await ref.once("value").then((snapshot) => {
        data = snapshot.val();
    });
    return data;
}


export async function checkForNewBestScore(score) {
    let scores = await getTopScores();
    const scoresArray = [...Object.entries(scores)];
    let index = scoresArray.findIndex(x => x[1].score < score);
    if (index != -1) {
        //we found new best score
        return true;
    }
    return false;
}


export async function setNewBestRecord(name, score) {

    //logic for removing the worst score

    //choose from which category you have to get the best score
    let scores = await getTopScores();
    const scoresArray = [...Object.entries(scores)];

    database.ref(`/gameScores/${scoresArray[indexOfMinScore][0]}`).remove();
    database.ref(`/Scores//${scoresArray[indexOfMinScore][0]}`).remove();


    //setting the new best score by category

    var data = {
        name,
        score
    }

    var newData = ref.push();
    newData.set(data);
}


export async function doesNameExist(name) {
    let scores = await getTopScores();
    const scoresArray = [...Object.entries(scores)];
    for (const current of scoresArray) {
        if (current[1].name == name) {
            return true;
        }
    }
    return false;
}