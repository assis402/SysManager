using System.ComponentModel;

namespace SysManager.Application.Errors
{
    public enum SysManagerErrors
    {
        #region User

        [Description("É ncessário informar a propriedade UserName")]
        User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty,

        [Description("É ncessário informar a propriedade Email")]
        User_Post_BadRequest_Email_Cannot_Be_Null_Or_Empty,

        [Description("É ncessário informar a propriedade Password")]
        User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty,

        [Description("Já existe um usuário com esse e-mail")]
        User_Post_BadRequest_Email_Cannot_Be_Duplicated,

        [Description("Usuário ou email inválido")]
        User_Put_BadRequest_UserName_Or_Email_Is_Invalid,

        [Description("É ncessário informar a propriedade NewPassword")]
        User_Put_BadRequest_NewPassword_Cannot_Be_Null_Or_Empty,

        #endregion User

        #region Unity

        [Description("É necessário informar o nome da unidade de medida")]
        Unity_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se a unidade é ativa ou inativa")]
        Unity_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe uma unidade de medida com esse nome")]
        Unity_Post_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("É necessário informar o id da unidade de medida")]
        Unity_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,

        [Description("Unidade de medida inválida ou inexistente")]
        Unity_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("É necessário informar o nome da unidade de medida")]
        Unity_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se a unidade é ativa ou inativa")]
        Unity_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe uma unidade de medida com esse nome")]
        Unity_Put_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("Unidade de medida inválida ou inexistente")]
        Unity_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,

        #endregion Unity

        #region Category

        [Description("É necessário informar o nome da categoria")]
        Category_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se a categoria é ativa ou inativa")]
        Category_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe uma categoria com esse nome")]
        Category_Post_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("É necessário informar o id da categoria")]
        Category_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,

        [Description("Categoria inválida ou inexistente")]
        Category_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("É necessário informar o nome da categoria")]
        Category_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se a categoria é ativa ou inativa")]
        Category_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe uma categoria com esse nome")]
        Category_Put_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("Categoria inválida ou inexistente")]
        Category_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,

        #endregion Category

        #region Product

        [Description("É necessário informar o nome do produto")]
        Product_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se o produto é ativo ou inativo")]
        Product_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe um produto com esse nome")]
        Product_Post_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("É necessário informar o id do produto")]
        Product_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,

        [Description("Produto inválido ou inexistente")]
        Product_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("É necessário informar o nome do produto")]
        Product_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se o produto é ativo ou inativo")]
        Product_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe um produto com esse nome")]
        Product_Put_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("Produto inválido ou inexistente")]
        Product_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,

        #endregion Product

        #region ProductType

        [Description("É necessário informar o nome do tipo de produto")]
        ProductType_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se o tipo de produto é ativo ou inativo")]
        ProductType_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe um tipo de produto com esse nome")]
        ProductType_Post_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("É necessário informar o id do tipo de produto")]
        ProductType_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,

        [Description("Tipo de produto inválido ou inexistente")]
        ProductType_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("É necessário informar o nome do tipo de produto")]
        ProductType_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se o tipo de produto é ativo ou inativo")]
        ProductType_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe um tipo de produto com esse nome")]
        ProductType_Put_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("Tipo de produto inválido ou inexistente")]
        ProductType_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,

        #endregion ProductType
    }
}