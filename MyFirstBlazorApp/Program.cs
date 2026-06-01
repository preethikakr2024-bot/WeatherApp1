@page "/"

<PageTitle>Student Form</PageTitle>

<h1>Student Details</h1>

<br />

<input @bind="name" placeholder="Enter your name" class= "form-control" />

< br />

< input @bind = "department" placeholder = "Enter department" class= "form-control" />

< br />

< button class= "btn btn-success" @onclick = "ShowDetails" >
    Submit
</ button >

< br />
< br />

< h3 > @message </ h3 >

@code {

    string name = "";
    string department = "";
    string message = "";

    void ShowDetails()
    {
        message = $"Hello {name} from {department} department!";
    }

}