# DynamicGraphics-Experiment-Project
(以下日本語)
This project has been developed by Clara HERTZOG as part of her doctoral program.
It has been developed for an experiment testing the effects of dynamic graphics on sports spectators watching sports games in Virtual Reality. 
This experiment has been ethically approved by UEC ethical committee.
The introduction of the experiment can be seen in the following video:
https://www.youtube.com/watch?v=a41DdV0ces4

This Unity project is meant to be launched on the Virtual Reality device Oculus Quest. 
It displays subsequently the scenes LaunchScene, Test 0, Test 1, etc. 
The scene LaunchScene is the first scene to be launched and displays a menu of the scenes of the project.
Scene 0 displays a reference video displaying a handball game without graphics.
Scenes 1 to 9 display different handball videos augmented with preconfigured graphics, blinking according to the dynamism of the game. 
The configuration of the graphics differs between the different scenes to test the most efficient configuration. 
The blinking pattern can be found in the Timeline of the EventTimeline object. 
The brightness setting is changed in the PostProcessVolume/Bloom/Color/Value setting of the WhiteGlow object.

More details about the graphics are given in the video below:
https://www.youtube.com/watch?v=qUCEHLPn0x4

The B button of the Oculus Quest controller is used to jump to the next scene and the Trigger button is used to go back to the previous scene.


このプロジェクトは、Clara HERTZOG によって博士課程プログラムの一環として開発されました。
これは、仮想現実でスポーツの試合を観戦するスポーツ観客に対するダイナミック グラフィックスの効果をテストする実験のために開発されました。
この実験は電気通信大学倫理委員会によって倫理的に承認されています。
実験の紹介は次のビデオで見ることができます。
https://www.youtube.com/watch?v=a41DdV0ces4

この Unity プロジェクトは、仮想現実デバイス Oculus Quest 上で起動されることを目的としています。
続いて、LaunchScene、Test 0、Test 1 などのシーンが表示されます。
LaunchScene シーンは最初に起動されるシーンで、プロジェクトのシーンのメニューが表示されます。
シーン 0 には、ハンドボールの試合をグラフィックスなしで表示する参考ビデオが表示されます。
シーン 1 ～ 9 では、事前設定されたグラフィックスで強化されたさまざまなハンドボール ビデオが表示され、試合のダイナミズムに応じて点滅します。
グラフィックスの構成はシーンごとに異なり、最も効率的な構成をテストします。
点滅パターンは、EventTimeline オブジェクトのタイムラインで確認できます。
明るさの設定は、WhiteGlow オブジェクトの PostProcessVolume/Bloom/Color/Value 設定で変更されます。

グラフィックの詳細については、以下のビデオで説明されています。
https://www.youtube.com/watch?v=qUCEHLPn0x4

Oculus Quest コントローラーの B ボタンは次のシーンにジャンプするために使用され、トリガー ボタンは前のシーンに戻るために使用されます。
