using System.Collections.Generic;

namespace ET.Client
{
    public static class MailHelper
    {
        public static async ETTask<List<MailInfo>> GetMailInfo(Scene root)
        {
            C2Mail_GetAllMailList request = C2Mail_GetAllMailList.Create();

            Mail2C_GetAllMailList response = (Mail2C_GetAllMailList)await root.GetComponent<ClientSenderComponent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return null;
            }

            return response.MailInfoList;
        }
    }
}