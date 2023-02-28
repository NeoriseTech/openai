﻿using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.FileResponseModels;
using OpenAI.GPT3.ObjectModels.SharedModels;

namespace OpenAI.GPT3.Interfaces;

public interface IFileService
{
    /// <summary>
    ///     Returns a list of files that belong to the user's organization.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<FileListResponse> ListFile(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all
    ///     the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage
    ///     limit.
    /// </summary>
    /// <param name="file">
    ///     Name of the <a href="https://jsonlines.readthedocs.io/en/latest/"> JSON Lines </a> file to be uploaded.
    ///     If the purpose is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing
    ///     your <a href="https://platform.openai.com/docs/guides/fine-tuning/prepare-training-data">training examples</a>.
    /// </param>
    /// <param name="fileName">Name of file</param>
    /// <param name="purpose">
    ///     The intended purpose of the uploaded documents.
    ///     Use "fine-tune" for <a href="https://platform.openai.com/docs/api-reference/fine-tunes">Fine-tuning</a>. This
    ///     allows us
    ///     to validate the format of the uploaded file.
    /// </param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<FileUploadResponse> UploadFile(string purpose, byte[] file, string fileName, CancellationToken cancellationToken = default);

    Task<FileUploadResponse> FileUpload(string purpose, Stream file, string fileName, CancellationToken cancellationToken = default)
    {
        return UploadFile(purpose, file.ToByteArray(), fileName);
    }

    Task<FileUploadResponse> FileUpload(UploadFilePurposes.UploadFilePurpose purpose, Stream file, string fileName, CancellationToken cancellationToken = default)
    {
        return UploadFile(purpose.EnumToString(), file.ToByteArray(), fileName, cancellationToken);
    }

    Task<FileUploadResponse> FileUpload(UploadFilePurposes.UploadFilePurpose purpose, byte[] file, string fileName, CancellationToken cancellationToken = default)
    {
        return UploadFile(purpose.EnumToString(), file, fileName, cancellationToken);
    }

    /// <summary>
    ///     Delete a file.
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<FileDeleteResponse> DeleteFile(string fileId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns information about a specific file.
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<FileResponse> RetrieveFile(string fileId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns the contents of the specified file
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task RetrieveFileContent(string fileId, CancellationToken cancellationToken = default);
}