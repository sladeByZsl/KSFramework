local UIzslPanel = {}
extends(UIzslPanel, UIBase)

function UIzslPanel:OnInit(controller)
    self.Controller = controller
    self.TitleLabel = self:GetUIText('Text0')
    self.ContentLabel = self:GetUIText('Text1')
end

function UIzslPanel:OnOpen()
	local rand=math.random(1,3)
    local billboardSetting=ZslSettings.Get("zsl"..tostring(rand))
    self.TitleLabel.text = billboardSetting.tt
    self.ContentLabel.text = billboardSetting.ww
    self.ContentLabel.text="fdfa"
end

return UIzslPanel