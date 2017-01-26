using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace ColorArt
{
    // @interface SLColorArt : NSObject
    [BaseType(typeof(NSObject))]
    interface SLColorArt
    {
        // @property (readonly, nonatomic, strong) UIColor * backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; }

        // @property (readonly, nonatomic, strong) UIColor * primaryColor;
        [Export("primaryColor", ArgumentSemantic.Strong)]
        UIColor PrimaryColor { get; }

        // @property (readonly, nonatomic, strong) UIColor * secondaryColor;
        [Export("secondaryColor", ArgumentSemantic.Strong)]
        UIColor SecondaryColor { get; }

        // @property (readonly, nonatomic, strong) UIColor * detailColor;
        [Export("detailColor", ArgumentSemantic.Strong)]
        UIColor DetailColor { get; }

        // @property (readonly, nonatomic) NSInteger randomColorThreshold;
        [Export("randomColorThreshold")]
        nint RandomColorThreshold { get; }

        // -(id)initWithImage:(UIImage *)image;
        [Export("initWithImage:")]
        IntPtr Constructor(UIImage image);

        // -(id)initWithImage:(UIImage *)image threshold:(NSInteger)threshold;
        [Export("initWithImage:threshold:")]
        IntPtr Constructor(UIImage image, nint threshold);

        // +(void)processImage:(UIImage *)image scaledToSize:(CGSize)scaleSize threshold:(NSInteger)threshold onComplete:(void (^)(SLColorArt *))completeBlock;
        [Static]
        [Export("processImage:scaledToSize:threshold:onComplete:")]
        void ProcessImage(UIImage image, CGSize scaleSize, nint threshold, Action<SLColorArt> completeBlock);
    }

    // @interface ColorArt (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_ColorArt
    {
        // -(SLColorArt *)colorArt;
        //[Export("colorArt")]
        //[Verify(MethodToProperty)]
        //SLColorArt ColorArt { get; }

        // -(SLColorArt *)colorArt:(CGSize)scale;
        [Export("colorArt:")]
        SLColorArt ColorArt(CGSize scale);
    }

    // @interface Scale (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_Scale
    {
        // -(UIImage *)scaledToSize:(CGSize)newSize;
        [Export("scaledToSize:")]
        UIImage ScaledToSize(CGSize newSize);
    }
}