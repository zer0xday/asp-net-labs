(function () {
    const alertElement = document.getElementById("success-alert");
    const formElement = document.forms[0];

    const addNewItem = async () => {
        // 1. read data from the form
        const endpoint = 'api/company';
        const requestData = JSON.stringify({
            Name: formElement.querySelector('input[name="Name"]').value,
            Description: formElement.querySelector('textarea[name="Description"]').value,
            isVisible: formElement.querySelector('input[name="IsVisible"]').checked
        });
        const config = {
            method: 'POST',
            body: requestData,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'RequestVerificationToken': formElement.querySelector('input[name="__RequestVerificationToken"]')
            }
        };

        //// 2. call the application server using fetch method
        const response = await fetch(endpoint, config);
        const responseJson = await response.json();

        if (responseJson.success) {
            // 3. un-hide the alertElement when the request has been successful
            alertElement.style.display = 'flex';
        }
    };
    window.addEventListener("load", () => {
        formElement.addEventListener("submit", event => {
            event.preventDefault();
            addNewItem().then(() => console.log("added successfully"));
        });
    });
})();