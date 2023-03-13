# 介绍
桌面整理美化工具，分为功能栏和任务栏上下两部分
**任务栏UI：** UI灵感来源于MacOS，文件夹下的快捷方式都将在此展示，从任务栏中打开软件后，会记录使用次数并排序，使用次数最多的3个软件将额外显示在最右侧，
**功能栏：** 包括搜索文件、文件分类（ppt、word、Excel、所有）、菜单（显示隐藏文件搜索功能、置顶、设置、关闭）、昼夜模式切换、时间、ToDo（待开发）
# UI界面
![image](https://github.com/MoYu030/DesktopFileOrganizer-WPF/blob/main/DesktopFileOrganizer/Resources/123123.png)
### 夜间（黑暗）模式UI
![image](https://github.com/MoYu030/DesktopFileOrganizer-WPF/blob/main/DesktopFileOrganizer/Resources/132132.png)
# 使用说明
把FileManager.cs文件中的filePath字符串修改为用于存放桌面文件的文件夹路径，并把快捷方式等文件拖入文件夹中，运行即可
# 注意
该程序中搜索框只搜索设置的文件夹下的所有文件，并非全局搜索
设置功能暂未开发，须手动在代码中修改
