
    document.addEventListener('DOMContentLoaded', function () {
        @foreach(var item in Model)
    {
        <text>
            addDivClickListener('C_@item.Id', 'b_@item.Id');
        </text>
    }
                });

    function addDivClickListener(divId, buttonId) {
            const myDiv = document.getElementById(divId);
    const myButton = document.getElementById(buttonId);

    if (myDiv && myButton) {
        myDiv.addEventListener('click', function () {
            myButton.click();
        });
            } else {
        console.error('Element(s) not found. Please check the IDs.');
            }
        }
