using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Templates
{
    public  class NewUserLoginTemplate
    {
        public static string GetBody(
            string firstName,
            string lastName,
            string email)
        {
            return $@"
<div style='font-family:Arial,sans-serif;
            max-width:600px;
            margin:auto;
            border:1px solid #e0e0e0;
            border-radius:10px;
            overflow:hidden;'>

    <div style='background-color:#22c55e;
                color:white;
                padding:20px;
                text-align:center;'>

        <h1 style='margin:0;'>Fundoo Notes</h1>

        <p style='margin-top:10px;font-size:14px;'>
            Connecting Worlds, Creating History
        </p>

    </div>

    <div style='padding:25px;'>

        <h2>Hello {firstName}! 👋</h2>

        <p>
            Your Fundoo Notes account has been created successfully.
        </p>

        <p>
            We're excited to have you on board.
            Every great journey begins with a single note. ✨
        </p>

        <div style='background:#f4f4f4;
                    padding:15px;
                    border-radius:8px;
                    margin-top:15px;'>

            <strong>Account Details</strong><br/>
            Name: {firstName} {lastName}<br/>
            Email: {email}

        </div>

        <p style='margin-top:20px;'>
            Thank you for joining Fundoo Notes.
            We look forward to helping you organize your ideas,
            memories, and goals.
        </p>

        <p>
            Best Wishes,<br/><br/>

            <strong>Amarnath Kolla</strong><br/>
            Cloud Researcher & .NET Trainee
        </p>

    </div>

    <div style='background:#f8f8f8;
                text-align:center;
                padding:12px;
                font-size:12px;
                color:#666;'>

        © Fundoo Notes | Welcome Aboard 🚀

    </div>

</div>";
        }
    }
}

