# CodeSnippetEditor
Visual Studio 用のスニペットを作成するアプリケーションです。

最低限の機能は完成したので公開します。

## デモンストレーション動画
スニペットの作成 -> 保存まで

https://user-images.githubusercontent.com/91731135/228750381-f2fdee92-603a-4086-ad1e-59723842b8cb.mp4

## システム要件
* Windows 10 64bit
* .NET 7.0 以上

## 使用言語
* C# .NET 7.0

## インストール方法
[こちら](https://github.com/crimson-tea/CodeSnippetEditor/releases/download/v0.1.0.0/CodeSnippetEditor.zip)より最新版をダウンロードしてください。その後、ダウンロードしたzipを展開してください。

起動できない場合は、[NET 7.0 Desktop Runtime](https://dotnet.microsoft.com/ja-jp/download/dotnet/thank-you/runtime-desktop-7.0.4-windows-x64-installer)のインストールをお試しください。

## 作成の動機
競技プログラミングをするにあたり、スニペットを複数登録したくなりました。  
Visual Studio でスニペットを登録するには Xml 形式のテキストを書く必要があります。  
そこで、ドキュメントを読みながら Xml を書き、いくつかスニペットを作成しましたが、やはり生の Xml を編集するのはとても怠かったので、スニペットを簡単に作成できるようなアプリケーションを作りたくなりました。

## 工夫と感想
Redux 概略図からをイメージを膨らませて状態管理を書いてみました。  
コードは若干長くなりましたが、一つ一つの操作がしっかり分離されていることや状態が一つの場所に集約されていることがよいところだと思いました。

## TODO 
- [ ] Undo 機能の実装
