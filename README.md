# 概要

カメラやUIのアスペクト対応をいい感じに初期設定してくれる自分用ライブラリ

### 動作確認環境

- Unity 2022.3.14f1

### 依存ライブラリ

特になし

# 使い方

- `Project` 欄を右クリックし、`Morn/MornAspectGlobalSettings`を作成する
    - 作成した`MornAspectGlobalSettings`を選択し、`Resolution`に設定したい解像度を設定する
- 任意の`Canvas`に`MornAspectCanvasScaler`をアタッチすると、自動でアスペクト比が設定される
- 任意の`Camera`に`MornAspectCamera`をアタッチすると、自動でアスペクト比が設定される

### その他

- `DefineSymbol` に `DISABLE_MORN_ASPECT_LOG` を設定すると、ログ出力を無効化できる
