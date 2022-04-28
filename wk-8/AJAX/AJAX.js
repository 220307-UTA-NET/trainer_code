document.addEventListener('DOMContentLoaded', () =>
{
    const dataInput = document.getElementById('data-input');
    const loadUserButton = document.getElementById('load-user-button');
    const loadTodosButton = document.getElementById('load-todos-button');
    const dataComponent = document.getElementById('data-component');
    const errorComponent = document.getElementById('error-component');

    loadTodosButton.addEventListener('click', () =>
    {
        fetch('https://jsonplaceholder.typicode.com/todos')
            .then(res =>
            {
                if(!res.ok)
                {
                    throw new Error(`server error ${res.status}`);
                }
                return res.json();
            })
            .then(obj =>
            {
                errorComponent.hidden = true;
                let html = `<ul>` + obj.map(x => `<li> ${x.title}</li>`).join() + `</ul>`;
                dataComponent.innerHTML = html;
            })
            .catch(error =>
            {
                errorComponent.hidden = false;
                errorComponent.textContent = error.message;
                dataComponent.textContent = '';
            });
    });

    loadUserButton.addEventListener('click', () =>
    {
        let url = `https://jsonplaceholder.typicode.com/users/${dataInput.value}`;

        fetch(url)
            .then(response =>
            {
                if(!response.ok)
                {
                    throw new Error(`server error ${response.status}`);
                }
                return response.json();
            })
            .then(obj =>
            {
                errorComponent.hidden = true;
                displayData(obj, dataComponent);
            })
            .catch(error =>
            {
                errorComponent.hidden = false;
                errorComponent.textContent = error.message;
                dataComponent.textContent = '';
            });
    });
});

function displayData(users, dataComponent)
{
    if(!(users instanceof Array))
    {
        users = [users];
    }

    let html = `<ul>`;

    for (let user of users)
    {
        html += `<li>${user.name}</li>`;
    }
    html += `</ul>`;

    dataComponent.innerHTML = html;
}
