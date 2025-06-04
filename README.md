# MornAspect

カメラやUIのアスペクト対応をいい感じに自動設定してくれる自分用ライブラリ

## 動作確認環境

- Unity 6 (6000.0.28f1)

## 依存ライブラリ

- MornGlobal

## 使い方

### 1. 設定作成
- `Project` 欄を右クリックし、`Morn/MornAspectGlobal`を作成する
- 作成したアセットで、`Resolution`に設定したい解像度を設定する（例: 1920x1080）

### 2. コンポーネントをアタッチ
- 任意の`Camera`に`MornAspectCamera`をアタッチ → 自動でアスペクト比設定
- 任意の`Canvas`に`MornAspectCanvas`をアタッチ → 自動でCanvasScaler設定  
- フルスクリーンUIの`RectTransform`に`MornAspectFullScreenUI`をアタッチ → 自動でサイズ調整

## 主な機能

- **カメラ**: レターボックス/ピラーボックス対応
- **Canvas**: 参照解像度とスケールモードの自動設定
- **UI**: サイズの自動調整
- **スケール調整**: `MornAspectCamera`で画面サイズの微調整可能