function startLifeTimer() {
    let birthdateInput = document.getElementById("birthdate").value;
    
    if (!birthdateInput) {
        alert("Prosím zadejte datum narození!");
        return;
    }

    let birthTime = new Date(birthdateInput).getTime();

    function updateLifeTime() {
        let now = new Date().getTime();
        let diff = now - birthTime;

        let years = Math.floor(diff / (1000 * 60 * 60 * 24 * 365.25));
        let days = Math.floor((diff % (1000 * 60 * 60 * 24 * 365.25)) / (1000 * 60 * 60 * 24));

        const text = `Váš věk: ${years} let, ${days} dní`;
        document.getElementById("ageDisplay").innerText = text;
        document.getElementById("ageDisplay").style = "display: flex";
    }

    updateLifeTime();
}
