using System.ComponentModel;

namespace SysManager.Application.Erros
{
    public enum SysManagerErrors
    {
        [Description("É ncessário informar a propriedade UserName")]
        User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty,

        [Description("É ncessário informar a propriedade Email")]
        User_Post_BadRequest_Email_Cannot_Be_Null_Or_Empty,

        [Description("É ncessário informar a propriedade Password")]
        User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty,
        
        [Description("Já existe um usuário com esse Email ou UserName")]
        User_Post_BadRequest_Email_Or_UserName_Cannot_Be_Duplicated,
    }
}