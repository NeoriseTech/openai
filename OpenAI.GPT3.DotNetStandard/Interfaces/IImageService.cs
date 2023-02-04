﻿using System.Threading.Tasks;
using OpenAI.GPT3.DotNetStandard.ObjectModels.RequestModels;
using OpenAI.GPT3.DotNetStandard.ObjectModels.ResponseModels.ImageResponseModel;

namespace OpenAI.GPT3.DotNetStandard.Interfaces;

/// <summary>
///     Given a prompt and/or an input image, the model will generate a new image.
///     Related guide: <a href="https://beta.openai.com/docs/guides/images">Image generation</a>
/// </summary>
public interface IImageService
{
    /// <summary>
    ///     Creates an image given a prompt.
    /// </summary>
    /// <param name="imageCreate"></param>
    /// <returns></returns>
    Task<ImageCreateResponse> CreateImage(ImageCreateRequest imageCreate);

    /// <summary>
    ///     Creates an image given a prompt.
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns></returns>
    Task<ImageCreateResponse> CreateImage(string prompt);

    /// <summary>
    ///     Creates an edited or extended image given an original image and a prompt.
    /// </summary>
    /// <param name="imageEditCreateRequest"></param>
    /// <returns></returns>
    Task<ImageCreateResponse> CreateImageEdit(ImageEditCreateRequest imageEditCreateRequest);

    /// <summary>
    ///     Creates a variation of a given image.
    /// </summary>
    /// <param name="imageEditCreateRequest"></param>
    /// <returns></returns>
    Task<ImageCreateResponse> CreateImageVariation(ImageVariationCreateRequest imageEditCreateRequest);
}