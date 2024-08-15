## UI组件命名规范
### 1. **Text 组件**

- **前缀**: `Txt_`

- 示例

  :

  - `Txt_Title`：表示标题文本。
  - `Txt_Description`：表示描述性文本。
  - `Txt_UsernameLabel`：表示用户名标签文本。

### 2. **Image 组件**

- **前缀**: `Img_`

- 示例

  :

  - `Img_Icon`：表示图标图片。
  - `Img_Background`：表示背景图片。
  - `Img_Avatar`：表示用户头像图片。

### 3. **Button 组件**

- **前缀**: `Btn_`

- 示例

  :

  - `Btn_Submit`：表示提交按钮。
  - `Btn_Cancel`：表示取消按钮。
  - `Btn_Next`：表示下一步按钮。

### 4. **InputField 组件**

- **前缀**: `Input_`

- 示例

  :

  - `Input_Username`：表示用户名输入框。
  - `Input_Password`：表示密码输入框。
  - `Input_Search`：表示搜索框。

### 5. **Toggle 组件**

- **前缀**: `Tgl_`

- 示例

  :

  - `Tgl_Option1`：表示选项1的开关。
  - `Tgl_Sound`：表示声音开关。
  - `Tgl_EnableFeature`：表示某功能的启用开关。

### 6. **Slider 组件**

- **前缀**: `Sld_`

- 示例

  :

  - `Sld_Volume`：表示音量调节滑块。
  - `Sld_Brightness`：表示亮度调节滑块。

### 7. **Dropdown 组件**

- **前缀**: `Dropdown_`

- 示例

  :

  - `Dropdown_Language`：表示语言选择下拉菜单。
  - `Dropdown_Resolution`：表示分辨率选择下拉菜单。

### 8. **Panel 组件**

- **前缀**: `Panel_`

- 示例

  :

  - `Panel_Settings`：表示设置面板。
  - `Panel_MainMenu`：表示主菜单面板。
  - `Panel_PauseMenu`：表示暂停菜单面板。

### 9. **Scrollbar 组件**

- **前缀**: `Scrollbar_`

- 示例

  :

  - `Scrollbar_Volume`：表示音量调节滚动条。
  - `Scrollbar_List`：表示列表滚动条。

### 10. **Canvas 组件**

- **前缀**: `Canvas_`

- 示例

  :

  - `Canvas_Main`：表示主画布。
  - `Canvas_HUD`：表示游戏内头显画布（HUD）。
  - `Canvas_Overlay`：表示覆盖画布。

### 11. **其他组件 (如 RawImage, ScrollView, 等)**

- 前缀

  根据组件类型进行命名：

  - `RawImg_`：表示 `RawImage` 组件，如 `RawImg_Background`。
  - `ScrollView_`：表示 `ScrollView` 组件，如 `ScrollView_Items`。
  - `ToggleGroup_`：表示 `ToggleGroup` 组件，如 `ToggleGroup_Options`。

### 12.层级结构参考：

- 如果一个组件属于某个特定的层级或模块，可以在名称中包含父级的功能描述。
- 示例

  :

- Panel_Settings_Txt_Volume 表示设置面板中的音量文本。
- Menu_Main_Btn_Start 表示主菜单中的开始按钮。

## 回调方法命名规范

### 1. **Button 回调方法**

- **命名格式**: `On[ButtonName]Clicked` 

- 示例

  :

  - `OnSubmitButtonClicked` ：表示提交按钮被点击时的回调方法。
  - `OnCancelButtonClicked` ：表示取消按钮被点击时的回调方法。
  - `OnNextButtonClicked` ：表示下一步按钮被点击时的回调方法。

### 2. **InputField 回调方法**

- **命名格式**: `On[InputFieldName]Changed` 
- **示例**:
  - `OnUsernameInputChanged`：表示用户名输入框内容改变时的回调方法。
  - `OnPasswordInputChanged`：表示密码输入框内容改变时的回调方法。
  - `OnSearchInputChanged` ：表示搜索框内容改变时的回调方法。
- **其他事件回调**:
  - `On[InputFieldName]EndEdit`：表示在输入框结束编辑时触发的事件。
  - 示例: `OnUsernameInputEndEdit` 表示用户名输入框编辑结束时的回调。

### 3. **Toggle 回调方法**

- **命名格式**: `On[ToggleName]Toggled` 
- **示例**:
  - `OnSoundToggleToggled` ：表示声音开关切换时的回调方法。
  - `OnFeatureToggleToggled`：表示某功能开关切换时的回调方法。
- **布尔值描述**:
  - 如果需要区分开启和关闭状态，可以使用 `On[ToggleName]Enabled` 和 `On[ToggleName]Disabled`。
  - 示例: `OnSoundToggleEnabled` 和 `OnSoundToggleDisabled`。

### 4. **Image 回调方法**

- **命名格式**: `On[ImageName]Clicked` 

- 示例

  :

  - `OnAvatarImageClicked` ：表示用户头像图片被点击时的回调方法。
  - `OnIconImageClicked` ：表示图标图片被点击时的回调方法。
